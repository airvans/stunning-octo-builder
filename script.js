
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

/*dos()

    

    async function dos(){
        fetch(url1)
       .then(response => {
        // Get the readable stream from the response body
        const stream = response.body;
        // Get the reader from the stream
        const reader = stream.getReader();
        // Define a function to read each chunk
        const readChunk = () => {
            // Read a chunk from the reader
            reader.read()
                .then(({
                    value,
                    done
                }) => {
                    // Check if the stream is done
                    if (done) {
                        // Log a message
                        console.log('Stream finished');
                        // Return from the function
                        return;
                    }
                    // Convert the chunk value to a string
                    const chunkString = new TextDecoder().decode(value);
                    // Log the chunk string
                    console.log(chunkString);
                    // Read the next chunk
                    readChunk();
                })
                .catch(error => {
                    // Log the error
                    console.error(error);
                });
        };
        // Start reading the first chunk
        readChunk();
    })
    .catch(error => {
        // Log the error
        console.error(error);
    });
   } */
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