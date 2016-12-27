import { TimesheetAppPage } from './app.po';

describe('timesheet-app App', function() {
  let page: TimesheetAppPage;

  beforeEach(() => {
    page = new TimesheetAppPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
