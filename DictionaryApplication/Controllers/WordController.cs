using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DictionaryApplication.Models;

namespace DictionaryApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly WordContext _context;

        public WordController(WordContext context)
        {
            _context = context;
        }

        // GET: api/Keywords
        [HttpGet]
        public IEnumerable<Word> GetWord()
        {
            return _context.Words.ToList();
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Keywords>>> GetKeywords()
        //{
        //    return await _context.Keywords.ToListAsync();
        //}

        // GET: api/Keywords/5
        [HttpGet("{id}")]
        public List<Word> GetWord(string id)
        {
            List<Word> word = new List<Word>();
            word = _context.Words.Where(cus => cus.WordTr == id || cus.WordEn == id).ToList();

            return word;
        }

        // PUT: api/Keywords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWord(int id, Word word)
        {
            if (id != word.Id)
            {
                return BadRequest();
            }

            _context.Entry(word).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordExists(id))
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

        // POST: api/Keywords
        [HttpPost]
        public async Task<ActionResult<Word>> PostKeywords(Word word)
        {
            _context.Words.Add(word);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWord", new { id = word.Id }, word);
        }

        // DELETE: api/Keywords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Word>> DeleteWord(int id)
        {
            var word = await _context.Words.FindAsync(id);
            if (word == null)
            {
                return NotFound();
            }

            _context.Words.Remove(word);
            await _context.SaveChangesAsync();

            return word;
        }

        private bool WordExists(int id)
        {
            return _context.Words.Any(e => e.Id == id);
        }
    }
}
