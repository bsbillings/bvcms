using Microsoft.Rest;
using System;
using System.Threading.Tasks;

namespace Touchpoint.Cms.Integrations.ESpace
{
    public class ESpaceApi
    {

    }

    public class ESpaceFacade
    {
        private readonly ESpaceClient _client;

        public ESpaceFacade() : this(null)
        {
            var c = new ESpaceClient(new Uri("app.espace.cool"), new BasicAuthenticationCredentials());
        }

        public ESpaceFacade(ESpaceClient client)
        {
            _client = client;
        }

        public async Task<GetOccurrencesResponse> GetOccurrences(GetOccurrencesRequest request)
        {
            var occurrences = await _client.EventsList.OccurrencesAsync("", 0, "");

            return null;
        }

        public GetOccurrenceResponse GetOccurrence(GetOccurrenceRequest request)
        {
            return null;
        }

        public GetEventsResponse GetEvents(GetEventsRequest request)
        {
            return null;
        }

        public GetItemsResponse GetItems(GetItemsRequest request)
        {
            return null;
        }

        public GetWebhooksResponse GetWebhooks(GetWebhooksRequest request)
        {
            return null;
        }

        public CreateWebhookResponse CreateWebhook(CreateWebhookRequest request)
        {
            return null;
        }

        public EditWebhookResponse EditWebhook(EditWebhookRequest request)
        {
            return null;
        }

        public DeleteWebhookResponse DeleteWebhook(DeleteWebhookRequest request)
        {
            return null;
        }

        public GetWebhookEventsResponse GetWebhookEvents(GetWebhookEventsRequest request)
        {
            return null;
        }
    }

    public class ESpaceItem
    {
        public int ItemId { get; set; }
        public string ItemType { get; set; }
        public string Name { get; set; }
        public string LocationName { get; set; }
        public int LocationId { get; set; }
        public int ParentId { get; set; }
        public string ParentName { get; set; }
        public bool IsSchedulable { get; set; }
    }

    public class GetOccurrencesRequest
    {

    }

    public class GetOccurrencesResponse
    {

    }

    public class GetOccurrenceRequest
    {

    }

    public class GetOccurrenceResponse
    {

    }

    public class GetEventsRequest
    {

    }

    public class GetEventsResponse
    {

    }

    public class GetItemsRequest
    {

    }

    public class GetItemsResponse
    {

    }

    public class GetWebhooksRequest
    {

    }

    public class GetWebhooksResponse
    {

    }

    public class CreateWebhookRequest
    {

    }

    public class CreateWebhookResponse
    {

    }

    public class EditWebhookRequest
    {

    }

    public class EditWebhookResponse
    {

    }

    public class DeleteWebhookRequest
    {

    }

    public class DeleteWebhookResponse
    {

    }

    public class GetWebhookEventsRequest
    {

    }

    public class GetWebhookEventsResponse
    {

    }
}
