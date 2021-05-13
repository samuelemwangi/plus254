export const formatDate = (date: string | number | Date): string => {
  const d = new Date(date);
  let month = `${d.getMonth() + 1}`;
  let day = `${d.getDate()}`;
  const year = d.getFullYear();

  if (month.length < 2) month = `0${month}`;
  if (day.length < 2) day = `0${day}`;

  return [year, month, day].join("-");
};

export const insertHtml = (content: any) => {
  const htmlItem = {
    __html: content,
  };
  return { dangerouslySetInnerHTML: htmlItem };
};

export const parseJwt = (token: string) => {
  const base64Url = token.split(".")[1];
  const base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/");
  const jsonPayload = decodeURIComponent(
    atob(base64)
      .split("")
      .map((c) => {
        return `%${`00${c.charCodeAt(0).toString(16)}`.slice(-2)}`;
      })
      .join("")
  );

  return JSON.parse(jsonPayload);
};

export const removeElementFromAnArray = <T>(
  arrayToManipulate: Array<T>,
  elementToRemove: T
) => {
  const elementIndexToRemove = arrayToManipulate.indexOf(elementToRemove);

  if (elementIndexToRemove > -1) {
    arrayToManipulate.splice(elementIndexToRemove, 1);
  }

  return arrayToManipulate;
};
