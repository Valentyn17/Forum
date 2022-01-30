using AutoMapper;
using Forum_BLL.DTO;
using Forum_PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum_PL.Infrastructure
{
    public class DtoModelsProfile: Profile
    {
        public DtoModelsProfile()
        {
            CreateMap<MessageDTO, MessageModel>()
                .ReverseMap();
            CreateMap<TopicModel, TopicDTO>()
                .ReverseMap();
            CreateMap<SectionModel, SectionDTO>()
                .ReverseMap();
          
        }
    }
}
