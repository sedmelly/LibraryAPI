using System;
using AutoMapper;
using LibraryApplication.Models;
using LibraryCore.Entities;

namespace LibraryApplication.Mapper
{
    public class LibraryMappingProfile :Profile
	{


        public LibraryMappingProfile()
        {
            CreateMap<Book, BookModel>().ReverseMap();
        }
    }


}




