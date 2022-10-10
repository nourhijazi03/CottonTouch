﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CottonTouch.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
                 {
                     x.AddProfile<DomainToViewModelMappingProfile>();
                     x.AddProfile<ViewModelToDomainMappingProfile>();
                 });
        }
    }
}