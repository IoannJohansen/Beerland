import axios, {AxiosResponse} from "axios";
import {GET_STAT_BY_DATE} from "./ApiBase";
import IDate from "../Interfaces/IDate";
import IStatisticViewModel from "../Interfaces/IStatisticViewModel";

export const getStatisticByDate = async (date : IDate) : Promise<AxiosResponse<Array<IStatisticViewModel>>> => {
    const response = await axios.get(GET_STAT_BY_DATE, {
        params: {
            date: `${date.Year}.${date.Month}.${date.Day}`
        }
    });
    return response;
}