
            using BuddyGo.Services;
            using Microsoft.AspNetCore.Mvc;
            using BuddyGo.DTOs.Offer;
            using BuddyGo.Models;

            namespace BuddyGo.Controllers {
                [Route("/offers")]
                public class OfferController : BaseController<Offer, OfferDTO, OfferCreateDTO, OfferUpdateDTO> {
                    private readonly IOfferService _offerService;
                    public OfferController(IOfferService offerService) : base(offerService) {
                        _offerService = offerService;
                    }
                }
            }
        