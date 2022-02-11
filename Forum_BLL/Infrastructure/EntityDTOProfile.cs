using AutoMapper;
using Forum_BLL.DTO;
using Forum_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum_BLL.Infrastructure
{
    public class EntityDTOProfile: Profile
    {
        public EntityDTOProfile()
        {
            CreateMap<UserProfile, UserDTO>()
                .ForMember(u => u.Id, opt => opt.MapFrom(up => up.UserId));

            CreateMap<UserDTO, UserProfile>()
                .ForMember(u => u.UserId, opt => opt.MapFrom(up => up.Id));
            CreateMap<MessageDTO, Message>()
                .ReverseMap();
            CreateMap<Topic, TopicDTO>()
                .ForMember(t => t.MessagesIds, opt => opt.MapFrom(a => a.Messages.Select(x => x.Id)))
                .ReverseMap();
            CreateMap<Section, SectionDTO>()
                .ForMember(s => s.TopicsIds, opt => opt.MapFrom(section => section.Topics.Select(t => t.Id)))
                .ReverseMap();
            CreateMap<User, UserDTO>()
                .ForMember(u => u.FirstName, opt => opt.MapFrom(up => up.UserProfile.FirstName))
                .ForMember(u => u.Email, opt => opt.MapFrom(up => up.Email))
                .ForMember(u => u.LastName, opt => opt.MapFrom(up => up.UserProfile.LastName))
                .ForMember(u => u.DateOfBirth, opt => opt.MapFrom(up => up.UserProfile.DateOfBirth)).ReverseMap();

        }
    }
}
