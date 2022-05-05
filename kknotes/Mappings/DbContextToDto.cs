using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using kknotes.Data.Entities;
using kknotes.Dto;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace kknotes.Mappings
{
    public class DbContextToDto : Profile
    {
        public DbContextToDto()
        {
            CreateMap<Note, NoteDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.NoteId))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ReverseMap();
        }
    }
}
