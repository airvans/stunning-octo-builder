using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;

[Route("/[controller]")]
public class OpenaiController:Controller{

private readonly IConfiguration configuration;


public OpenaiController(IConfiguration configuration){

    this.configuration = configuration;

}

[Route("/")]
[HttpGet]
public IActionResult index(){

return Ok("success");

}

[Route("getcontent")]
[HttpPost]
 public async Task<IActionResult> Getcontent([FromBody] Content content){
   
   var connect = configuration["apikey"];
   var api = new OpenAIAPI(connect);  
   var testapi= api.Chat.CreateConversation();
   testapi.RequestParameters.Model = "gpt-4o";
   testapi.AppendSystemMessage("You will be provided with first a job description text and next a user resume text (delimited by XML tags). using the information provided generate a 170 words cover letter. the generated response should just be only the body content, no salutation and complimentary close included the cover letter"); 
   testapi.AppendUserInput($"<article>{content.Jobdescription}</article>,<article>{content.Jobresume}</article>");
   var results= await testapi.GetResponseFromChatbotAsync();
   return Ok(results);
    
 }

 [Route("gettitle")]
 [HttpPost]
 public async Task<IActionResult> Gettitle([FromBody] string content){
   
   var connect = configuration["apikey"];
   var api = new OpenAIAPI(connect);  

   var testapi= api.Chat.CreateConversation();
   testapi.RequestParameters.Model = "gpt-4o";
   testapi.AppendSystemMessage("You will be provided with a job description enclosed in XML tags. suggest an appropriate job title for the role. with a prefix that says \"Title : \"."); 
   testapi.AppendUserInput($"<article>{content}</article>");
   var results= await testapi.GetResponseFromChatbotAsync();
   return Ok(results);
    
 }

  [Route("gettitlejson")]
 [HttpPost]
 public async Task<IActionResult> Gettitlejson([FromBody] string content){
   
   var connect = configuration["apikey"];
   var api = new OpenAIAPI(connect);  

   ChatRequest chatRequest = new ChatRequest()
     {
	    Model = Model.GPT4_Turbo,
	    Temperature = 0.0,
	    MaxTokens = 500,
	    ResponseFormat = ChatRequest.ResponseFormats.JsonObject,
	    Messages = [
		    new ChatMessage(ChatMessageRole.System, "You will be provided with a job description of articles (delimited with XML tags). extract the job title from the job description as JSON with prexif \"jobtitle\" "),
		    new ChatMessage(ChatMessageRole.User,$"<article>{content}</article>")
	     ]
    };

    var results = await api.Chat.CreateChatCompletionAsync(chatRequest);
    return Ok(results.ToString());
     
 }

 [Route("content")]
 [HttpGet]
 public async Task<IActionResult> content(){
   
   await Task.Delay(5000);

   var response = @"  Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. 
       --- Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.
        Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.
       ";

    return Ok(new{word="success",response});
  }



[Route("returnview")]
[HttpGet]
 public IActionResult test(){

    return View();
 }

[Route("returnviewalt")]
[HttpGet]
 public IActionResult testalt(){

    return View();
 }

[Route("/private")]
[HttpGet]
 private async IAsyncEnumerable<string> Doing(){
       
       var connect = configuration["apikey"];
       var api = new OpenAIAPI(connect);

        var testapi= api.Chat.CreateConversation();

        testapi.AppendUserInput("how to make cheese");


       await foreach (var res in testapi.StreamResponseEnumerableFromChatbotAsync())
       {
        
        yield return res;
              
       }

 }

[Route("/simulation")]
[HttpGet]
 public async IAsyncEnumerable<string> testrun(){
   
   
   string[] arr = { "hi", "my", "name", "is", "kobe", "i", "am", "a", "lost", "boy",
                    "this", "is", "an", "example", "of", "a", "longer", "array", "for", "testing",
                    "purpose", "to", "simulate", "an", "async", "task", "check", "in", "c#", "code",
                    "with", "more", "elements", "to", "yield", "asynchronously", "from", "the", "dosomething",
                    "method", "in", "the", "testrun", "method"};

    await foreach (var res in dosomething(arr)){

        yield return res;

    };

 }

  private async IAsyncEnumerable<string> dosomething(string[] arr){

      foreach(string s in arr){
          
           await Task.Delay(100);
           yield return s;
      }

    }

}

