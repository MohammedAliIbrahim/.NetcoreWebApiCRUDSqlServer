using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeadCoreAreas.Models;
using LeadCoreAreas.Areas.Models;
namespace LeadCoreAreas.Areas.Product.Controllers
{
     [Route("api/[controller]")]
    
    [ApiController]
    public class productsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public productsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/products
        [HttpPost("GetProducts")]
        public async Task<CommonResponse> GetProducts(PagingFilter pagingfilter)
        {

            if (pagingfilter.Page != null)
            {
                var page = pagingfilter.Page;
                var count = pagingfilter.PageSize;
                var takePage = page ?? 1;
                var takeCount = count ?? 10;

                var PagedProducts = await _context.Products
                                .Skip((takePage - 1) * takeCount)
                                .Take(takeCount)
                                .ToListAsync(); 


               // var PagedProducts = await _context.Products.ToListAsync();
                return new CommonResponse(1, "Store.Products.AddSuccess", PagedProducts);
            }
            if (pagingfilter.ID != null)
            {
                var product = await _context.Products.FindAsync(pagingfilter.ID);

                if (product == null)
                {
                    return new CommonResponse(-1, "Store.Products.GetFail", product);
                    //  return NotFound();
                }

                return new CommonResponse(1, "Store.Products.GetSuccess", product);


            }

            if (pagingfilter.Query != null)
            {
                var productsSearch =  _context.Products.Where(x=>x.ProductName.Contains(pagingfilter.Query));

              

                return new CommonResponse(1, "Store.Products.GetSuccess", productsSearch);



            }
            var products = await _context.Products.ToListAsync();
            return new CommonResponse(1, "Store.Products.GetSuccess", products);
            //  return new CommonResponse(-1, "Contat.Products.AddFail", products);
        }

        // GET: api/products/5


        //[HttpGet("{id}")]
        //public async Task<Common> Getproduct(int id)
        //{
        //    var product = await _context.Products.FindAsync(id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return product;
        //}

        // PUT: api/products/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Putproduct(int id, product product)
        //{
        //    if (id != product.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(product).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!productExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/products
        [HttpPost("AddOrEditProduct")]
        public async Task<ActionResult<CommonResponse>> Postproduct(int? ProductId, product product)
        {



            if (ProductId.HasValue)
            {

                if (ProductId != product.ProductId)
                {
                    return new CommonResponse(-1, "Store.Products.EditFail");
                    //  return BadRequest();
                }

                _context.Entry(product).State = EntityState.Modified;
               

                try
                {
                    await _context.SaveChangesAsync();
                    return new CommonResponse(1, "Store.Products.EditSuccess");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!productExists(ProductId))
                    {
                        return new CommonResponse(-1, "Store.Products.EditFail");
                        //return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                //return NoContent();
                //return new CommonResponse(-1, "Store.Products.EditFail");
            }
            else
            {

                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return new CommonResponse(1, "Store.Products.AddSuccess");
            }
            // return CreatedAtAction("Getproduct", new { id = product.Id }, product);
        }

        // DELETE: api/products/5
       [HttpDelete("DeleteProduct/{ProductId}")]
        
        public async Task<ActionResult<CommonResponse>> Deleteproduct(int ProductId)
        {
            var product = await _context.Products.FindAsync(ProductId);
            if (product == null)
            {
                return new CommonResponse(-1, "Store.Products.DeletetFail");
                // return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return new CommonResponse(-1, "Store.Products.DeleteSuccess");
            // return product;
        }

        private bool productExists(int? ProducId)
        {
            return _context.Products.Any(e =>e.ProductId == ProducId);
        }
    }
}
