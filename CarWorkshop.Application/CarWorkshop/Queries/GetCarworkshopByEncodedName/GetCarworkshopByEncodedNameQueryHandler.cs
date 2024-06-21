using AutoMapper;
using CarWorkshop.Application.CarWorkshop.Queries.GetCarWorkshopByEncodedName;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarWorkshop.Application.CarWorkshop.Queries.GetCarworkshopByEncodedName
{
    public class GetCarworkshopByEncodedNameQueryHandler : IRequestHandler <GetCarWorkshopByEncodedNameQuery, CarWorkshopDto>

    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly IMapper mapper;

        public GetCarworkshopByEncodedNameQueryHandler(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
        {
            _carWorkshopRepository = carWorkshopRepository;
            this.mapper = mapper;
        }
        public async Task<CarWorkshopDto> Handle(GetCarWorkshopByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _carWorkshopRepository.GetByEncodedName(request.EncodedName);
            var dto = mapper.Map<CarWorkshopDto>(carWorkshop); 
            return dto;
        }
    }
}
