import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ListedUser } from '../models/listeduser';

@Injectable()
export class UserListService {
  listedUser: ListedUser[];
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
    public getUserList() {
    const endPoint = 'users/list';
      
      //return //this.http.get(this.baseUrl + endPoint);
          this.http.get<ListedUser[]>(this.baseUrl + endPoint).subscribe(result => {
    this.listedUser = result;
    }, error => console.error(error));
    }
  
}
