﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetWebAPI.Models;

namespace DotNetWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryContext _context;

        public InventoryController(InventoryContext context)
        {
            _context = context;
        }

        // GET: api/Inventory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryItem>>> GetInventory()
        {
            return await _context.Inventory.ToListAsync();
        }

        // GET: api/Inventory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryItem>> GetInventoryItem(string id)
        {
            var inventoryItem = await _context.Inventory.FindAsync(id);

            if (inventoryItem == null)
            {
                return NotFound();
            }

            return inventoryItem;
        }

        // PUT: api/Inventory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventoryItem(string id, InventoryItem inventoryItem)
        {
            if (id != inventoryItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(inventoryItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Inventory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InventoryItem>> PostInventoryItem(InventoryItem inventoryItem)
        {
            _context.Inventory.Add(inventoryItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InventoryItemExists(inventoryItem.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInventoryItem", new { id = inventoryItem.Id }, inventoryItem);
        }

        // DELETE: api/Inventory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryItem(string id)
        {
            var inventoryItem = await _context.Inventory.FindAsync(id);
            if (inventoryItem == null)
            {
                return NotFound();
            }

            _context.Inventory.Remove(inventoryItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventoryItemExists(string id)
        {
            return _context.Inventory.Any(e => e.Id == id);
        }
    }
}
