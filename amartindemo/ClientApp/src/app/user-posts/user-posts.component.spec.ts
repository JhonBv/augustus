/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { UserPostsComponent } from './user-posts.component';

let component: UserPostsComponent;
let fixture: ComponentFixture<UserPostsComponent>;

describe('user-posts component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ UserPostsComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(UserPostsComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});