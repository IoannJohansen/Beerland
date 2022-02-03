import axios, {AxiosResponse} from "axios";
import { GET_STAT_BY_DATE} from "./ApiBase";
import IDate from "../Interfaces/IDate";
import {axiosResponseHandler} from "./AxiosResponseHandler";

export const getStatisticByDate = async <T>(date : IDate, onSuccess : Function, onFail : Function) => {
    const response = await axios.get(GET_STAT_BY_DATE, {
        params: {
            date: `${date.Year}.${date.Month}.${date.Day}`
        }
    });
    axiosResponseHandler<AxiosResponse<T>>(response, onSuccess, onFail);
}