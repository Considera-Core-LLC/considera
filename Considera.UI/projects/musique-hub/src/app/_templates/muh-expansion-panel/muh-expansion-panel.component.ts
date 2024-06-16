import {Component, Input} from '@angular/core';

@Component({
  selector: 'muh-expansion-panel',
  templateUrl: './muh-expansion-panel.component.html',
  styleUrls: ['./muh-expansion-panel.component.scss']
})
export class MuhExpansionPanelComponent {
  @Input() public title: string = '';
  @Input() public description: string = '';
  @Input() public expanded: boolean = true;
}
