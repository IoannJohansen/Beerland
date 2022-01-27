import {EMonth} from "../Enums/EMonth";

export const numToMonth = (num : Number) : String => {
    return EMonth[Number(num)];
}

export const monthToNum = (month : String) : Number => {
    return EMonth[String(month)];
}

export const eMonthToArray = () : String[] => Object.keys(EMonth).filter(item=>{return isNaN(Number(item))})