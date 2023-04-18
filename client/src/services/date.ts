export const formatDate = (date: Date): string => {
    const now = date;
    let month: number | string = (now.getMonth() + 1);               
    let day: number | string = now.getDate();
    if (month < 10) 
        month = "0" + month;
    if (day < 10) 
        day = "0" + day;
    const today = now.getFullYear() + '-' + month + '-' + day;
    return today;

}