﻿using AutoMapper;
using Mango.Service.ProductAPI.Models;
using Mango.Service.ProductAPI.Models.Dto;

namespace Mango.Service.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();                
            });

            return mapperConfig;
        }
    }
}
