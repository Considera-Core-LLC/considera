import {Component, Input} from '@angular/core';

@Component({
  selector: 'muh-input-section',
  templateUrl: './muh-input-section.component.html',
  styleUrls: ['./muh-input-section.component.scss']
})
export class MuhInputSectionComponent {
  @Input() public title: string = ''
}
