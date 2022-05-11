
            using AutoMapper;
            using BuddyGo.DTOs.Announcement;
            using BuddyGo.Models;
            
            namespace BuddyGo.Maps {
                public class AnnouncementMap : Profile {
                    public AnnouncementMap() {
                        CreateMap<Announcement, AnnouncementDTO>();
                        CreateMap<AnnouncementCreateDTO, Announcement>();
                        CreateMap<AnnouncementUpdateDTO, Announcement>();
                    }
                }
            }
        