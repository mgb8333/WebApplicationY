using Domain.Enums;
using Domain.Interfaces;
using System.Configuration;
using System.Web.Http;

namespace WebApplicationY.Controllers
{
    public class MessageController : ApiController
    {
        IMessageItemRepository _repository;

        public MessageController(IMessageItemRepository repository)
        {
            _repository = repository;
        }

        public IHttpActionResult GetMessageItem(int id)
        {
            string outputKey = ConfigurationManager.AppSettings["UnspecifiedOutputDirection"] != null ? ConfigurationManager.AppSettings["UnspecifiedOutputDirection"] : "Console";

            var messageItem = _repository.GetById(id);
            if (messageItem == null)
            {
                return NotFound();
            }

            // Sample application requirement to make use of web.config app key/value.
            // Using it here to set the direction of any message that has a type of 'Unspecified' (3)
            if (messageItem.MessageType == (int)ApplicationEnums.MessageTypes.Unspecified)
            {
                if (outputKey.Trim().ToLower().Equals("console"))
                {
                    messageItem.MessageType = (int)ApplicationEnums.MessageTypes.Console;
                }
                else
                {
                    messageItem.MessageType = (int)ApplicationEnums.MessageTypes.Webpage;
                }
            }
                
            return Ok(messageItem);
        }


        // Could add Put's, other Get's, and Delete method's here as well as needed.
        // Typically I would use a few data annotations on the class/methods to eliminate the need to constantly
        // update the routing classes.
        //
        // For example - add a route prefix on the class:
        // [RoutePrefix("api/Message")]
        //
        // And then Route data annotations on the individual methods to free up the need to mess with the routing:
        // [Route("GetMessageItem/{id}")]


        // Added for sake of requirements of the exercise - commented out due to simplicity (i.e. no DB and no "Add" method in repo at this point)
        // Typically there would be a common "Repository.cs" file with all the basic methods in it to handle the simple stuff, and also
        // DBContext and UnitOfWork classes.
        //
        //public HttpResponseMessage Post(MessageItem item)
        //{
        //    _repository.Add(item);

        //    var response = Request.CreateResponse(HttpStatusCode.Created, item);
        //    string uri = Url.Link("DefaultApi", new { id = item.Id });
        //    response.Headers.Location = new Uri(uri);

        //    return response;
        //}
    }
}
