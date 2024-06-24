using Microsoft.AspNetCore.Mvc;

[Route("/[controller]")]
public class OpenaiController:Controller{

[Route("/")]
[HttpGet]
public IActionResult index(){

return Ok("success");

}

[Route("getcontent")]
[HttpGet]
 public IActionResult Getcontent(){
    return Ok("success");
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

}