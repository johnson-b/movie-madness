function test() {
    PageMethods.doSomething(); 
    function onSuccess(result) {
        alert(result);
    }
    function onError(result) {
        alert('Something went wrong');
    }
}