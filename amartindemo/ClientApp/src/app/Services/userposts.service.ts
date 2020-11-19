import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserDetails } from '../models/userdetails';

@Injectable({
providedIn: 'root',
})
export class UserpostsService {
  public userDetails: UserDetails[];
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  public getUserDetails(userId: number){

    this.http.get<UserDetails[]>(this.baseUrl + 'users/details/'+userId).subscribe(result => {
      this.userDetails = result;
    }, error => console.error(error));

  }
}

