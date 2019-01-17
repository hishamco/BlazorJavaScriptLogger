window.jsLogger = {
    log: function (level, message) {
        switch (level) {
            case 'Trace':
                console.trace(message);
                break;
            case 'Debug':
                console.debug(message);
                break;
            case 'Information':
                console.info(message);
                break;
            case 'Warning':
                console.warn(message);
                break;
            case 'Error':
            case 'Critical':
                console.error(message);
                break;
        }
    }
}