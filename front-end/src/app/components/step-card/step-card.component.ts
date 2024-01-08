import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-step-card',
  templateUrl: './step-card.component.html',
  styleUrls: ['./step-card.component.scss']
})
export class StepCardComponent {

    //Variables
    //For test at the moment, to be sure stuff works
    @Input() stepDescription!: string;
    @Input() stepNumber!: number;
    //Functions
}
