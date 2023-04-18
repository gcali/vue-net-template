export const readFile = async (file: File): Promise<string> => {
  const promise = new Promise<string>((res, rej) => {
    const fileReader = new FileReader();
    fileReader.onload = function() {
      const text = fileReader.result;
      if (typeof text !== "string") {
        rej("Invalid type: " + typeof text);
      } else {
        res(text);
      }
    };
    fileReader.readAsText(file);
  });
  return promise;
};

export const exportFile = async (data: string, filename: string): Promise<void> => {
  const a = document.createElement("a");
  const blob = new Blob([data], {
    type: "application/json",
  });

  a.href = URL.createObjectURL(blob);
  a.setAttribute("download", filename);
  a.click();

  return new Promise<void>((res) => res());
};
