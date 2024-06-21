import {Injectable} from "@angular/core";
import moment from "moment";

@Injectable({
  providedIn: 'root'
})
export class DateService {
  public static getWordedDate(date: Date): string {
    return moment(date).format('MMMM Do, YYYY');
  }
}
