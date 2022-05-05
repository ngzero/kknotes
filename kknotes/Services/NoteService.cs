using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using kknotes.Data.Entities;
using kknotes.Data.Repositories.Interfaces;
using kknotes.Dto;
using kknotes.Services.Interfaces;

namespace kknotes.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;

        public NoteService(INoteRepository noteRepository, IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
        }
        public async Task<List<NoteDto>> GetNotesAsync()
        {
            var notes = await _noteRepository.GetNotesAsync();
            var noteDtos = _mapper.Map<List<NoteDto>>(notes);
            return noteDtos;
        }

        public async Task<NoteDto> GetNoteAsync(int id)
        {
            var note = await _noteRepository.GetNoteAsync(id);
            var noteDto = _mapper.Map<NoteDto>(note);
            return noteDto;
        }

        public async Task<bool> CreateNoteAsync(NoteDto noteDto)
        {
            var note = _mapper.Map<Note>(noteDto);
            return await _noteRepository.CreateNoteAsync(note);
        }

        public async Task<bool> UpdateNoteAsync(NoteDto noteDto)
        {
            var note = _mapper.Map<Note>(noteDto);
            return await _noteRepository.UpdateNoteAsync(note);
        }

        public async Task<bool> DeleteNoteAsync(int id)
        {
            return await _noteRepository.DeleteNoteAsync(id);
        }
    }
}
