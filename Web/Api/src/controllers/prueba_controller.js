var controller = {
    testGet: (req, res) => {
        return res.status(200).send({
            message: 'Hello World!!!'
        })
    },

}

module.exports = controller;