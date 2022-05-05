using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kknotes.Data.Entities;
using kknotes.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace kknotes.Data.Repositories
{
    public class NotesRepository : INoteRepository
    {
        private readonly NotesDbContext _context;

        public NotesRepository(NotesDbContext context)
        {
            _context = context;
        }
        public async Task<List<Note>> GetNotesAsync()
        {
            return await _context.Notes.ToListAsync();
        }

        public async Task<Note> GetNoteAsync(int id)
        {
            return await _context.Notes.SingleOrDefaultAsync(x => x.NoteId == id);
        }

        public async Task<bool> CreateNoteAsync(Note note)
        {
            await _context.Notes.AddAsync(note);
            var added = await _context.SaveChangesAsync();
            return added > 0;
        }

        public async Task<bool> UpdateNoteAsync(Note note)
        {
            var dbNote = await GetNoteAsync(note.NoteId);
            if (dbNote == null)
                return false;
            _context.Entry(dbNote).CurrentValues.SetValues(note);
            var updated = await _context.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteNoteAsync(int id)
        {
            var dbNote = await GetNoteAsync(id);
            if (dbNote == null)
                return false;
            _context.Remove(dbNote);
            var removed = await _context.SaveChangesAsync();
            return removed > 0;
        }
    }
}
