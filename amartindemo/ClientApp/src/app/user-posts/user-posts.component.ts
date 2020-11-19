import { Component, Input } from '@angular/core';
import { User } from '../models/user';
import { UserpostsService } from '../Services/userposts.service';

@Component({
    selector: 'app-user-posts',
    templateUrl: './user-posts.component.html',
    styleUrls: ['./user-posts.component.css']
})
/** user-posts component*/
export class UserPostsComponent {
  @Input() userId: number;
  public udetails: User[];
  public posstUrl: string;

  constructor(private userdetails: UserpostsService) {

    this.userdetails.getUserDetails(this.userId);

  }
    
}
