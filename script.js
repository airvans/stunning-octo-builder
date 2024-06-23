
document.getElementById("download").addEventListener("click",pro)

function pro(){
    var element = document.getElementById('container');

    var opt = {
    margin:        [1,0.5,0,0.5],
    filename:     'Evan.pdf',
    image:        { type: 'jpeg', quality: 1 },
    html2canvas:  { scale: 1 },
    jsPDF:        { unit: 'in', format: 'a4', orientation: 'portrait' }
       };
    html2pdf(element,opt);
    console.log("done");
} 


// // var element = document.getElementById('rectangle-1');
// // var opt = {
// //     margin:        [0.5,0.5,1,0.5],
// //     filename:     'Evan.pdf',
// //     image:        { type: 'jpeg', quality: 1 },
// //     html2canvas:  { scale: 1 },
// //     jsPDF:        { unit: 'in', format: 'letter', orientation: 'portrait' }
// //   };

// // if (element) {
// //     html2pdf(element,opt);
// // } else {
// //     console.error("Element with ID 'rectangle-1' not found.");
// // }