using Oid85.Health.Application.Interfaces.Repositories;
using Oid85.Health.Application.Interfaces.Services;
using Oid85.Health.Common.Helpers;
using Oid85.Health.Common.KnownConstants;
using Oid85.Health.Core.Models;
using Oid85.Health.Core.Requests;
using Oid85.Health.Core.Responses;

namespace Oid85.Health.Application.Services
{
    /// <inheritdoc/>
    public class GlucoseService(
        IGlucoseRepository glucoseRepository)
        : IGlucoseService
    {
        /// <inheritdoc/>
        public async Task<GetGlucoseListResponse?> GetGlucoseListAsync(GetGlucoseListRequest request)
        {
            var dates = DateHelper.GetDates(request.From, request.To).OrderDescending();

            var glucoses = await glucoseRepository.GetGlucosesAsync(request.From, request.To);

            if (glucoses is null)
                return null;

            var response = new GetGlucoseListResponse()
            {
                DayItems = dates.Select(x => GetGlucose(x)).ToList()
            };

            GetGlucoseListDayItem GetGlucose(DateOnly date)
            {
                var glucose = glucoses.Find(x => x.Date == date);

                return glucose is not null
                    ? new GetGlucoseListDayItem()
                    {
                        Id = glucose.Id,
                        Date = date,
                        BeforeMorningFood = glucose.BeforeMorningFood,
                        AfterMorningFood = glucose.AfterMorningFood,
                        BeforeTraining = glucose.BeforeTraining,
                        AfterTraining = glucose.AfterTraining,
                        BeforeEveningFood = glucose.BeforeEveningFood,
                        BeforeNight = glucose.BeforeNight
                    }
                    : new GetGlucoseListDayItem()
                    {
                        Id = Guid.NewGuid(),
                        Date = date,
                        BeforeMorningFood = null,
                        AfterMorningFood = null,
                        BeforeTraining = null,
                        AfterTraining = null,
                        BeforeEveningFood = null,
                        BeforeNight = null
                    };

            }

            return response;
        }

        /// <inheritdoc/>
        public async Task<SetGlucoseResponse?> SetGlucoseAsync(SetGlucoseRequest request)
        {
            var glucose = await glucoseRepository.GetGlucoseByDateAsync(request.Date);

            if (glucose is null)
            {
                var id = await glucoseRepository.CreateGlucoseAsync(
                    new Glucose
                    {
                        Date = DateOnly.FromDateTime(DateTime.Today),
                        BeforeMorningFood = null,
                        AfterMorningFood = null,
                        BeforeTraining = null,
                        AfterTraining = null,
                        BeforeEveningFood = null,
                        BeforeNight = null
                    });

                if (!id.HasValue)
                    return null;

                glucose = await glucoseRepository.GetGlucoseByDateAsync(request.Date);
            }
            
            if (glucose is  null)
                return null;

            switch (request.Type)
            {
                case KnownGlucoseTypes.BeforeMorningFood:
                    glucose.BeforeMorningFood = request.Value;
                    break;

                case KnownGlucoseTypes.AfterMorningFood:
                    glucose.AfterMorningFood = request.Value;
                    break;

                case KnownGlucoseTypes.BeforeTraining:
                    glucose.BeforeTraining = request.Value;
                    break;

                case KnownGlucoseTypes.AfterTraining:
                    glucose.AfterTraining = request.Value;
                    break;

                case KnownGlucoseTypes.BeforeEveningFood:
                    glucose.BeforeEveningFood = request.Value;
                    break;

                case KnownGlucoseTypes.BeforeNight:
                    glucose.BeforeNight = request.Value;
                    break;

                default:
                    break;
            }

            var glucoseId = await glucoseRepository.EditGlucoseAsync(glucose);

            if (!glucoseId.HasValue)
                return null;

            var response = new SetGlucoseResponse() { Id = glucoseId.Value };

            return response;
        }
    }
}
