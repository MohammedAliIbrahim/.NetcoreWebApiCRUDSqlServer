using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeadCoreAreas.Models;
using LeadCoreAreas.Areas.Store;
using LeadCoreAreas.Areas.Models;

namespace LeadCoreAreas.Areas.Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public StoresController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Stores
        //    [HttpGet]
        //    public async Task<ActionResult<IEnumerable<store>>> GetStores()
        //    {
        //        return await _context.Stores.ToListAsync();
        //    }

        //    // GET: api/Stores/5
        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<store>> GetStore(int id)
        //    {
        //        var store = await _context.Stores.FindAsync(id);

        //        if (store == null)
        //        {
        //            return NotFound();
        //        }

        //        return store;
        //    }

        //    // PUT: api/Stores/5
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutStore(int id, store store)
        //    {
        //        if (id != store.StoreId)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(store).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!StoreExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    // POST: api/Stores
        //    [HttpPost]
        //    public async Task<ActionResult<store>> PostStore(store store)
        //    {
        //        _context.Stores.Add(store);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("GetStore", new { id = store.StoreId }, store);
        //    }

        //    // DELETE: api/Stores/5
        //    [HttpDelete("{id}")]
        //    public async Task<ActionResult<store>> DeleteStore(int id)
        //    {
        //        var store = await _context.Stores.FindAsync(id);
        //        if (store == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Stores.Remove(store);
        //        await _context.SaveChangesAsync();

        //        return store;
        //    }

        //    private bool StoreExists(int StoreId)
        //    {
        //        return _context.Stores.Any(e => e.StoreId == StoreId);
        //    }
        //}


        // GET: api/stores
        [HttpPost("GetGetStores")]
        public async Task<CommonResponse> GetStores(PagingFilter pagingfilter)
        {

            if (pagingfilter.Page != null)
            {

                //var takePage = page ?? 1;
                //var takeCount = count ?? DefaultPageRecordCount;

                //var calls = context.Stores
                //                .Skip((takePage - 1) * takeCount)
                //                .Take(takeCount)
                //                .ToList();

                var page = pagingfilter.Page;
                var count = pagingfilter.PageSize;
                var takePage = page ?? 1;
                var takeCount = count ?? 10;


                var PagedStores = await _context.Stores
                                .Skip((takePage - 1) * takeCount)
                                .Take(takeCount)
                                .ToListAsync(); ;


                //  var PagedStores = await _context.Stores.ToListAsync();
                return new CommonResponse(1, "Store.Stores.AddSuccess", PagedStores);
            }
            if (pagingfilter.ID != null)
            {
                var store = await _context.Stores.FindAsync(pagingfilter.ID);

                if (store == null)
                {
                    return new CommonResponse(-1, "Store.Stores.GetFail", store);
                    //  return NotFound();
                }

                return new CommonResponse(1, "Store.Stores.GetSuccess", store);


            }

            if (pagingfilter.Query != null)
            {
                var storesSearch = _context.Stores.Where(x => x.StoreName.Contains(pagingfilter.Query));



                return new CommonResponse(1, "Store.Stores.GetSuccess", storesSearch);



            }
            var stores = await _context.Stores.ToListAsync();
            return new CommonResponse(1, "Store.Stores.GetSuccess", stores);
            //  return new CommonResponse(-1, "Contat.Stores.AddFail", stores);
        }

        // GET: api/stores/5


        //[HttpGet("{id}")]
        //public async Task<Common> Getstore(int id)
        //{
        //    var store = await _context.Stores.FindAsync(id);

        //    if (store == null)
        //    {
        //        return NotFound();
        //    }

        //    return store;
        //}

        // PUT: api/stores/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Putstore(int id, store store)
        //{
        //    if (id != store.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(store).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!storeExists(id))
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

        // POST: api/stores
        [HttpPost("AddOrEditStore")]
        public async Task<ActionResult<CommonResponse>> Poststore(int? StoreId, store store)
        {



            if (StoreId.HasValue)
            {

                if (StoreId != store.StoreId)
                {
                    return new CommonResponse(-1, "Store.Stores.EditFail");
                    //  return BadRequest();
                }

                _context.Entry(store).State = EntityState.Modified;


                try
                {
                    await _context.SaveChangesAsync();
                    return new CommonResponse(1, "Store.Stores.EditSuccess");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!storeExists(StoreId))
                    {
                        return new CommonResponse(-1, "Store.Stores.EditFail");
                        //return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                //return NoContent();
                //return new CommonResponse(-1, "Store.Stores.EditFail");
            }
            else
            {

                _context.Stores.Add(store);
                await _context.SaveChangesAsync();
                return new CommonResponse(1, "Store.Stores.AddSuccess");
            }
            // return CreatedAtAction("Getstore", new { id = store.Id }, store);
        }

        // DELETE: api/stores/5
        //[HttpDelete("{id}")]
        [HttpDelete("DeleteStore/{StoreId}")]
        public async Task<ActionResult<CommonResponse>> Deletestore(int StoreId)
        {
            var store = await _context.Stores.FindAsync(StoreId);
            if (store == null)
            {
                return new CommonResponse(-1, "Store.Stores.DeletetFail");
                // return NotFound();
            }

            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();
            return new CommonResponse(-1, "Store.Stores.DeleteSuccess");
            // return store;
        }

        private bool storeExists(int? StoreId)
        {
            return _context.Stores.Any(e => e.StoreId == StoreId );
        }
    }

}
