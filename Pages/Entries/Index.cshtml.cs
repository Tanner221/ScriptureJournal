using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Models;

namespace ScriptureJournal.Pages.Entries
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesEntryContext _context;

        public IndexModel(RazorPagesEntryContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string Keyword { get; set; }

        public SelectList Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string bookSearch { get; set; }
        public IList<Entry> Entry { get;set; } = default!;

        public async Task OnGetAsync()
        {
          IQueryable<string> bookQuery = from entry in _context.Entry
                                          orderby entry.Book
                                          select entry.Book;
          var entries = from e in _context.Entry 
                                    select e;

          if(!string.IsNullOrEmpty(Keyword))
          {
            entries = entries.Where(e => e.Note.ToLower().Contains(Keyword.ToLower()));
          }

          if(!string.IsNullOrEmpty(bookSearch))
          {
            entries = entries.Where((x => x.Book == bookSearch));
          }
          Books = new SelectList(await bookQuery.Distinct().ToListAsync());
          Entry = await entries.ToListAsync();
        }
    }
}
