using System;
using AutoMapper;

namespace LibraryApplication.Mapper
{
	public class LibraryMapper
	{
		public LibraryMapper()
        {


		}

        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<LibraryMappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });



        public static IMapper Mapper => Lazy.Value;

       
    }

  
}


