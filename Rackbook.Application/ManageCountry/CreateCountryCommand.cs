using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageCountry
{
    public class CreateCountryCommand : IRequest<GenericResult<Country>>
    {
        public Country model { get; set; }

        private class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, GenericResult<Country>>
        {
            private readonly ICountryRepository _country;
            public CreateCountryCommandHandler(ICountryRepository country)
            {
                this._country = country;
            }
            public async Task<GenericResult<Country>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
            {
                GenericResult<Country> Result = new GenericResult<Country>();
                try
                {
                    if (request.model is null)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._country.AddAsync(request.model);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.CountryName} has saved successfully.";
                        }
                        else
                        {
                            Result.Status = false;
                            Result.Message = $"An error occurred while insert record.";
                        }
                    }

                    return Result;
                }
                catch (Exception ex)
                {
                    Result.Status = false;
                    Result.Message = ex.Message;
                    return Result;
                }
            }
        }
    }
}
