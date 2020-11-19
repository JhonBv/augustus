import { Injectable } from '@angular/core';

@Injectable()
export class BaseService {

  public apiRootUrl: string = "https://localhost:44339/";

  constructor() {

  }
}
