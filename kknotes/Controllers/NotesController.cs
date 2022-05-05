using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using kknotes.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using kknotes.Models;
using kknotes.Services.Interfaces;

namespace kknotes.Controllers
{
    public class NotesController : Controller
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }
        public async Task<IActionResult> Index()
        {
            var noteDtos = await _noteService.GetNotesAsync();
            return View(noteDtos);
        }

        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var noteDto = await _noteService.GetNoteAsync(id);
            return View(noteDto);
        }

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _noteService.DeleteNoteAsync(id);
            if (!deleted)
                return NotFound();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Save([FromForm] NoteDto noteDto)
        {
            if (noteDto.Id == 0){
                var result = await _noteService.CreateNoteAsync(noteDto);
                if (!result) return Error();
            }
            else
            {
                var result = await _noteService.UpdateNoteAsync(noteDto);
                if (!result) return Error();
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
