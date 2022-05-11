
            using AutoMapper;
            using BuddyGo.DTOs.Announcement;
            using BuddyGo.Models;
            using BuddyGo.Repositories;
            
            namespace BuddyGo.Services.Impl {
                public class AnnouncementService : BaseService<Announcement, AnnouncementDTO, AnnouncementCreateDTO, AnnouncementUpdateDTO>, IAnnouncementService {
                    private readonly IAnnouncementRepository _repository;
                    
                    public AnnouncementService(IAnnouncementRepository repository, IMapper mapper) : base(repository, mapper) {
                        _repository = repository;
                    }
                }
            }        
        