import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDirComponent } from './add-dir.component';

describe('AddDirComponent', () => {
  let component: AddDirComponent;
  let fixture: ComponentFixture<AddDirComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddDirComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddDirComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
