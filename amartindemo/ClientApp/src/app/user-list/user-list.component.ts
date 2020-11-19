import { Component, Inject } from '@angular/core';
//Jhon B. Importing the user model as it is in a separate directory
import { ListedUser } from '../models/listeduser';
import { User } from '../models/user';
import { HttpClient } from '@angular/common/http';

//Jhon B. The imports below are there as I planned to use a Servie to act as the Proxy. Did not get it to work but the code is left commented so the reader can appreciate my resoning.

//import { BaseService } from '../Services/base.service';
//import { UserListService } from '../Services/user-list.service';

@Component({
    selector: 'app-user-list',
    templateUrl: './user-list.component.html',
    styleUrls: ['./user-list.component.css']
})

/** user-list component*/
export class UserListComponent{

  public users: ListedUser[];
  selectedUser: ListedUser;
  public udetails: User[];
    /** Jhon B. It is always a good practice to delegate this responsibility to a Service. I could not make it work and due to time constrains I did not have enough time to find an answer.
     I leave it commented out so that the reader can see my reasoning. Eventually I had to fetch the data from the same Component but I would definitely preferred delegating to the Service*/

  //constructor(private root: BaseService, private userlist: UserListService) {

  //  userlist.getUserList().subscribe(userlist => {this.users = userlist as User[] })
  //  }

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string ) {

    http.get<ListedUser[]>(baseUrl + 'users/list').subscribe(result => {
    this.users = result;
    }, error => console.error(error));

  }

  onSelect(theuser: ListedUser): void {
    this.selectedUser = theuser;
    //this.userdetails.getUserDetails(theuser.id);
    alert('Selected ' + theuser.id);
  }
}
