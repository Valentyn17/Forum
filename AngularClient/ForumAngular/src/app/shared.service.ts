import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable, retryWhen } from 'rxjs';
import { first, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl = "http://localhost:49414";
  
    constructor(private http: HttpClient) { }


    getSectionList():Observable<any[]>{
      return this.http.get<any>(this.APIUrl+'/Section');
    }

    addSection(val: any){
      return this.http.post(this.APIUrl+'/Section', val);
    }
  
    updateSection(val: any){
      return this.http.put(this.APIUrl+'/Section', val);
    }
    deleteSection(val: any){
      return this.http.delete(this.APIUrl+'/Section/'+val);
    }

    //topics
    getTopicList():Observable<any[]>{
      return this.http.get<any>(this.APIUrl+'/Topic');
    }

    addTopic(val: any){
      return this.http.post(this.APIUrl+'/Topic', val);
    }
  
    updateTopic(val: any){
      return this.http.put(this.APIUrl+'/Topic', val);
    }
    deleteTopic(val: any){
      return this.http.delete(this.APIUrl+'/Topic/'+val);
    }
    getTopicListBySection(val: any):Observable<any[]>{
      return this.http.get<any>(this.APIUrl+'/Topic/getBySectionId/'+val);
    }

    


}
