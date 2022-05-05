using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kknotes.Data.Entities;
using kknotes.Dto;

namespace kknotes.Services.Interfaces
{
    public interface INoteService
    {
        Task<List<NoteDto>> GetNotesAsync();
        Task<NoteDto> GetNoteAsync(int id);
        Task<bool> CreateNoteAsync(NoteDto noteDto);
        Task<bool> UpdateNoteAsync(NoteDto noteDto);
        Task<bool> DeleteNoteAsync(int id);
    }
}
