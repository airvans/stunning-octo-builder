document.addEventListener("DOMContentLoaded", function () {
  document.getElementById("download").addEventListener("click", generatePDF);
});

function generatePDF() {
  const element = document.getElementById("content");

  // Options for html2pdf
  const opt = {
    margin: [0.5, 0.5, 0.5, 0.5], // Add some margin
    filename: "resume.pdf",
    image: { type: "jpeg", quality: 0.98 },
    html2canvas: { scale: 2, logging: true, dpi: 192, letterRendering: true },
    jsPDF: { unit: "in", format: "letter", orientation: "portrait" },
  };

  // New Promise-based usage:
  html2pdf().set(opt).from(element).save();
}
