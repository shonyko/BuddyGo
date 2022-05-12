
            using AutoMapper;
            using BuddyGo.DTOs.Offer;
            using BuddyGo.Models;
            
            namespace BuddyGo.Maps {
                public class OfferMap : Profile {
                    public OfferMap() {
                        CreateMap<Offer, OfferDTO>();
                        CreateMap<OfferCreateDTO, Offer>();
                        CreateMap<OfferUpdateDTO, Offer>();
                    }
                }
            }
        