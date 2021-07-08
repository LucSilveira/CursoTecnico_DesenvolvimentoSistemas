

using DoLink.Dominio.Commands;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using Microsoft.Azure.CognitiveServices.ContentModerator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DoLink.Comum.Utils
{
    public class ContentModerator
    {

        private static readonly string AzureEndpoint = "https://azurecontentmoderatordolink.cognitiveservices.azure.com/";

        /// <summary>
        /// Your Content Moderator subscription key.
        /// </summary>
        private static readonly string CMSubscriptionKey = "c9d8a8c2d91045889c371d37e76f06fd";

        /// <summary>
        /// Returns a new Content Moderator client for your subscription.
        /// </summary>
        /// <returns>The new client.</returns>
        /// <remarks>The <see cref="ContentModeratorClient"/> is disposable.
        /// When you have finished using the client,
        /// you should dispose of it either directly or indirectly. </remarks>
        public IList<DetectedTerms> Moderar(string texto)
        {
            // Create and initialize an instance of the Content Moderator API wrapper.
            ContentModeratorClient client = new ContentModeratorClient(new ApiKeyServiceClientCredentials(CMSubscriptionKey));
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(texto));
            client.Endpoint = AzureEndpoint;
            var reultado = client.TextModeration.ScreenText("text/plain", stream );
            return reultado.Terms;
        }

        /// <summary>
        /// Creates a new term list.
        /// </summary>
        /// <param name="client">The Content Moderator client.</param>
        /// <returns>The term list ID.</returns>
        static string CreateTermList(ContentModeratorClient client)
        {

            Body body = new Body("Inadequadas", "Palavras inadequadas");
            TermList list = client.ListManagementTermLists.Create("application/json", body);
            if (false == list.Id.HasValue)
            {
                throw new Exception("TermList.Id value missing.");
            }
            else
            {
                string list_id = list.Id.Value.ToString();
                return list_id;
            }
        }


        /// <summary>
        /// Screen the indicated text for terms in the indicated term list.
        /// </summary>
        /// <param name="client">The Content Moderator client.</param>
        /// <param name="list_id">The ID of the term list to use to screen the text.</param>
        /// <param name="text">The text to screen.</param>
        public GenericCommandResult ScreensText(ContentModeratorClient client, string list_id, string text)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(text));
            var screen = client.TextModeration.ScreenText("Por", stream, text, false, false, list_id);
            if (null != screen.Terms)
            {
                return new GenericCommandResult(false, "Palavras que ferem nossa politca ", screen.Terms);
            }
            return null;
        }

        /// <summary>
        /// Add a term to the indicated term list.
        /// </summary>
        /// <param name="client">The Content Moderator client.</param>
        /// <param name="list_id">The ID of the term list to update.</param>
        /// <param name="term">The term to add to the term list.</param>
        static void AddTerm(ContentModeratorClient client, string list_id, string term)
        {
            client.ListManagementTerm.AddTerm(list_id, term, "por");
        }
        
            public IList<DetectedTerms> ModeradorTermos (string texto)
            {
                ContentModeratorClient client = new ContentModeratorClient(new ApiKeyServiceClientCredentials(CMSubscriptionKey));
            client.Endpoint = AzureEndpoint;
            string list_id = CreateTermList(client);

                AddTerm(client, list_id, "batata");
                AddTerm(client, list_id, "term2");
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(texto));
                client.Endpoint = AzureEndpoint;
                ScreensText(client, "text/plain", texto);
            return null;
            }
        

    }
}
