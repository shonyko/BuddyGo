
            using AutoMapper;
            using BuddyGo.DTOs.Offer;
            using BuddyGo.Models;
            using BuddyGo.Repositories;
            
            namespace BuddyGo.Services.Impl {
                public class OfferService : BaseService<Offer, OfferDTO, OfferCreateDTO, OfferUpdateDTO>, IOfferService {
                    private readonly IOfferRepository _repository;
                    
                    public OfferService(IOfferRepository repository, IMapper mapper) : base(repository, mapper) {
                        _repository = repository;
                    }
                }
            }        
        