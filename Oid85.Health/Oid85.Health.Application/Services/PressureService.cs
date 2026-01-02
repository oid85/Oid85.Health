using Oid85.Health.Application.Interfaces.Repositories;
using Oid85.Health.Application.Interfaces.Services;
using Oid85.Health.Common.Helpers;
using Oid85.Health.Core.Models;
using Oid85.Health.Core.Requests;
using Oid85.Health.Core.Responses;

namespace Oid85.Health.Application.Services
{
    /// <inheritdoc/>
    public class PressureService(
        IPressureRepository pressureRepository)
        : IPressureService
    {
        /// <inheritdoc/>
        public async Task<CreatePressureResponse?> CreatePressureAsync(CreatePressureRequest request)
        {
            var model = new Pressure
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                Time = TimeOnly.FromDateTime(DateTime.Now),
                Sys = request.Sys,
                Dia = request.Dia,
                Pulse = request.Pulse
            };

            var id = await pressureRepository.CreatePressureAsync(model);

            if (id is null)
                return null;

            var response = new CreatePressureResponse
            {
                Id = id.Value
            };

            return response;
        }

        /// <inheritdoc/>
        public async Task<GetPressureListResponse?> GetPressureListAsync(GetPressureListRequest request)
        {
            var dates = DateHelper.GetDates(request.From, request.To).OrderDescending();
            
            List<TimeOnly> times = 
                [
                    TimeOnly.Parse("08:00"),
                    TimeOnly.Parse("09:00"),
                    TimeOnly.Parse("10:00"),
                    TimeOnly.Parse("11:00"),
                    TimeOnly.Parse("12:00"),
                    TimeOnly.Parse("13:00"),
                    TimeOnly.Parse("14:00"),
                    TimeOnly.Parse("15:00"),
                    TimeOnly.Parse("16:00"),
                    TimeOnly.Parse("17:00"),
                    TimeOnly.Parse("18:00"),
                    TimeOnly.Parse("19:00"),
                    TimeOnly.Parse("20:00"),
                    TimeOnly.Parse("21:00"),
                    TimeOnly.Parse("22:00"),
                    TimeOnly.Parse("23:00")
                ];

            var pressures = await pressureRepository.GetPressuresAsync(request.From, request.To);

            if (pressures is null)
                return null;    

            var response = new GetPressureListResponse
            {
                DayItems = dates.Select(date => new GetPressureListDayItem 
                { 
                    Date = date, 
                    IntraDayItems = times.Select(x => GetPressure(date, x)).ToList()
                }).ToList()
            };

            return response;

            GetPressureListIntraDayItem GetPressure(DateOnly date, TimeOnly time)
            {
                var pressure = pressures.FindLast(
                    x => x.Date == date && x.Time > time.AddMinutes(-30) && x.Time < time.AddMinutes(30));

                if (pressure is null)
                    return new GetPressureListIntraDayItem { Time = time };

                return new GetPressureListIntraDayItem { Time = time, Sys = pressure.Sys, Dia = pressure.Dia, Pulse = pressure.Pulse };
            }
        }
    }
}
