var moives ={
    name:"sam",
    duration:"2hours",
    rating:1
}
var x;
function updateDetails(){
    moives.name=document.getElementById("moiveName").value ;
    moives.duration=document.getElementById("moiveDuration").value;
   // moives.rating=document.getElementById("moiveRating").value;
   moives.rating=x;
    console.log(moives)
    document.getElementById("moiveName").value="" ;
    document.getElementById("moiveDuration").value="";
    document.getElementById("moiveRating").value=0;
    
}
function  printDetails(){
    var x = document.createElement("TR");
    x.setAttribute("id","myTr");
   var d= document.getElementById("mytable").appendChild(x);
    d.innerHTML= "<td>"+ moives.name +"</td>" + "<td>"+ moives.duration +"</td>" +"<td>"+ moives.rating +"</td>" ;
  }
  function getRange(){
    x= document.getElementById("ranges").value;
  }