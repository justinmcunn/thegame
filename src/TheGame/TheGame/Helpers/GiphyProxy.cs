using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace TheGame.Helpers
{
    /// <summary>
    /// A Helper class for accessing the Giphy API to populate rediculous images that will appear
    /// to shame the recipient on top of already losing the game.
    /// </summary>
    public class GiphyProxy
    {
        /// <summary>
        /// A method to return a random Gif file to embarrass the victim from the Giphy API.
        /// </summary>
        /// <returns>The URL for a hopefully relevant and hilarious image.</returns>
        public async Task<string> GetRandomGif(string tag)
        {
            try
            {
                // Call the Gyphy API to pull an image of someone or something laughing at your loss
                using (var client = new HttpClient())
                {
                    // Set the API to a private key during release
                    var apiKey = "dc6zaTOxFJmzC";

                    // Determine the fate of the recipient by generating a random category and constructing an endpoint
                    var target = String.Format("http://api.giphy.com/v1/gifs/random?api_key={0}&tag={1}",apiKey, tag ?? GetRandomTag());
                    // Hit the Glypy API and pull an image
                    var request = await client.GetStringAsync(target);
                    // Deserialize the request and pull out what we need
                    var result = Json.Decode(request);
                    // All kinds of casting an null reference nastiness could occur here, but who cares
                    return ((dynamic)((DynamicJsonObject)(result))).data.image_url;
                }
            }
            catch (Exception ex)
            {
                // Something bad happened, so just return a null and let Fiddy' handle business
                return null;
            }
        }

        /// <summary>
        /// A method to generate a random tag to use as a focal point to punk the victim
        /// </summary>
        /// <returns>A random word to use to query the Giphy API</returns>
        private string GetRandomTag()
        {
            // With so many expressions to convey losing the game, it's tough to pick just one
            var tags = new[] { "mind blown", "laugh", "frustrated", "surprised", "facepalm", "lol", "mic drop", "laugh", "shocked" };
            return tags[new Random((int)DateTime.UtcNow.Ticks).Next(tags.Length)];
        }
    }
}